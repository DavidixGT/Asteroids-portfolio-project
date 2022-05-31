using System.Threading.Tasks;

namespace Asteroids.Utilities
{
    public class CoolDown
    {
        public bool IsCompleted => _coolDown.IsCompleted;
        private Task _coolDown;
        private int _coolDownTime;
        public CoolDown(int coolDownTime)
        {
            _coolDownTime = coolDownTime;
            _coolDown = Task.Delay(coolDownTime);
        }
        public async Task StartCoolDown()
        {
            await _coolDown;
            _coolDown = Task.Delay(_coolDownTime);
        }
    }
}