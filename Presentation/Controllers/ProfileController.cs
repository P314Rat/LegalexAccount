using Application.Core.BusinessLogic.AccountProcess.EditProfile;
using Application.Core.DTO;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.EditProfile;


namespace Presentation.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        private readonly IMapper _mapper;


        public ProfileController(IMediator mediator, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mediator, httpContextAccessor)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGeneral(GeneralViewModel model)
        {
            model.Email = User.Identity.Name;
            var profile = _mapper.Map<ProfileDTO>(model);
            await _mediator.Send(new EditGeneralCommand(profile));

            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateOrganization(GeneralViewModel model)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult UpdateBankAccount(GeneralViewModel model)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult UpdateDocuments(GeneralViewModel model)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult UpdateSecurity(GeneralViewModel model)
        {
            return Ok();
        }
    }
}
