using AutoMapper;
using Data;
using Data.Entities;
using DoraMetrics.DTOs;
using Helpers.ClientServices;
using Integrations.JiraServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DoraMetrics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JiraController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;        
        private readonly IMapper _mapper;        
        private readonly IIssueServices _issueServices;
        private readonly IIssueEventRepo _issueEventRepo;
        private readonly IUnitOfWork _db;

        public JiraController (ILogger<HomeController> logger, IConfiguration configuration,
             IMapper mapper, IUnitOfWork db, IIssueServices issueServices, IIssueEventRepo issueEventRepo)
        {
            _logger = logger;
            _config = configuration;            
            _mapper = mapper;           
            _db = db;           
            _issueServices = issueServices;
            _issueEventRepo = issueEventRepo;
        }

        [HttpPost("/JiraIssueEventWebhook")]
        public async Task<IActionResult> JiraIssueEventWebhook(JiraIssueEventDto jiraIssueEventDto)
        {
            if (jiraIssueEventDto == null)
                return NoContent();
            var issueEvent = await _issueEventRepo.GetIssueEventWithJiraId(jiraIssueEventDto.issue.id);
            if (issueEvent == null)
            {
                var mappedJiraIssueEvent = _mapper.Map<JiraIssueEvent>(jiraIssueEventDto);
                _db.Add(mappedJiraIssueEvent);
                var jiraResponse = await ChangeJiraIssueStatus(jiraIssueEventDto.issue.key,
                    Integrations.JiraServices.Services.IssueStatus.InProgress);
                //1 - Payment Process
                //2 - Edit DB mappedJiraIssueEvent.Paid = true , mappedJiraIssueEvent.PaidAt = DateTime.Now;
                //await _db.SaveAll();

                jiraResponse = await ChangeJiraIssueStatus(jiraIssueEventDto.issue.key, 
                    Integrations.JiraServices.Services.IssueStatus.Done);
                if (jiraResponse.IsSuccess)
                    return Ok(jiraResponse);
            }
            else if (issueEvent.Paid)
            {
                var mappedJiraIssueEvent = _mapper.Map<JiraIssueEvent>(jiraIssueEventDto);
                mappedJiraIssueEvent.Paid = true;
                mappedJiraIssueEvent.PaidAt = issueEvent.PaidAt;
                _db.Add(mappedJiraIssueEvent);
                await _db.SaveAll();
                return Ok();
            }
            else
            {
                _db.Delete(issueEvent);
                var jiraResponse = await ChangeJiraIssueStatus(jiraIssueEventDto.issue.key,
                    Integrations.JiraServices.Services.IssueStatus.InProgress);
                //1 - Payment Process
                //2 - Edit mappedJiraIssueEvent.Paid = true , mappedJiraIssueEvent.PaidAt = DateTime.Now;
                await _db.SaveAll();
                jiraResponse = await ChangeJiraIssueStatus(jiraIssueEventDto.issue.key, 
                    Integrations.JiraServices.Services.IssueStatus.Done);
                if (jiraResponse.IsSuccess)
                    return Ok(jiraResponse);
            }
            return BadRequest();
        }

        public async Task<ApiResponse> ChangeJiraIssueStatus(string issueKey, 
            Integrations.JiraServices.Services.IssueStatus issueStatus)
        {
            var accessToken = _config.GetSection("JiraService:ApiToken").Value;
            var accessTokenEncoded = Encoding.UTF8.GetBytes(accessToken.ToString());
            var at64 = Convert.ToBase64String(accessTokenEncoded);
            var jiraResponse = await _issueServices
                .SetIssueStatus<ApiResponse>(issueKey,
                issueStatus, at64);

            return jiraResponse;
        }

    }
}
