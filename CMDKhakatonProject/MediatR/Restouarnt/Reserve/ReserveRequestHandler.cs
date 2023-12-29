using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;
using CMDKhakatonProject.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMDKhakatonProject.MediatR.Restouarnt
{
    public class ReserveRequestHandler : IRequestHandler<ReserveRequest, IActionResult>
    {
        private readonly IRepository<Reservation> _reservationRepository;
        private readonly UserManager<AppUser> _userManager;

        public ReserveRequestHandler(UserManager<AppUser> userManager, IRepository<Reservation> reservationRepository)
        {
            _userManager = userManager;
            _reservationRepository = reservationRepository;
        }

        public async Task<IActionResult> Handle(ReserveRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(request.User);

            Reservation reservation = new()
            {
                TableId = request.TableId,
                Phone = request.Phone,
                DateTime = request.DateTime,
                ReserverId = user.Id,
            };

            _reservationRepository.Add(reservation);

            return new OkObjectResult(ActionMessages.Reserve());
        }
    }
}
