package pl.retsuz.exchange;

import pl.retsuz.currency.ICurrency;



public class Exchange implements IExchange{

    public static Exchange singleton = null;

    private Exchange(){};

    public static Exchange getInstance()
    {
        if(singleton == null)
        {
            singleton = new Exchange();
        }
        return singleton;
    }

    @Override
    public double exchange(ICurrency src, ICurrency tgt, double amt) {
        return amt*src.getRate()*tgt.getFactor()/src.getFactor()*tgt.getRate();
    }
}
