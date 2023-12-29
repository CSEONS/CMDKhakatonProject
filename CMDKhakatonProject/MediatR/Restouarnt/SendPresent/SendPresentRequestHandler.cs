using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMDKhakatonProject.MediatR.Restouarnt
{
    public class SendPresentRequestHandler : IRequestHandler<SendPresentRequest, IActionResult>
    {
        private readonly IRepository<Present> _presentRepository;

        public SendPresentRequestHandler(IRepository<Present> presentRepository)
        {
            _presentRepository = presentRepository;
        }

        public Task<IActionResult> Handle(SendPresentRequest request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
