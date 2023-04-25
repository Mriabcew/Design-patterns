namespace FirebrigadeSim.JRGModel.CarModel.CarState
{
    public class OnHold : ICarState
    {
        public void next(Car car)
        {
            car.State = new OnTheWay();
        }

        //#TODO Dopisac nie wiem jeszcze co :)
        public void previous(Car car)
        {

        }
    }
}
