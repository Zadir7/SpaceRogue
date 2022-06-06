using Abstracts;

namespace Gameplay.Player.Movement
{
    public class StarMovementController : BaseController
    {
        private readonly StarMovementModel _movementModel;
        private readonly StarView _view;

        public StarMovementController(
            StarMovementModel movementModel,
            StarView view)
        {
            _movementModel = movementModel;
            _view = view;
        }
    }
}