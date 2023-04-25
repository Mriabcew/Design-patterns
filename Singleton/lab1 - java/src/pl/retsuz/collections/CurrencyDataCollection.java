package pl.retsuz.collections;


import pl.retsuz.currency.ICurrency;

import javax.xml.crypto.Data;
import java.util.ArrayList;
import java.util.List;

public class CurrencyDataCollection implements IDataCollection {

    public static CurrencyDataCollection singleton = null;
    private List<ICurrency> DataCollection = new ArrayList<>();

    private CurrencyDataCollection() {
    }

    public static CurrencyDataCollection getInstance()
    {
        if(singleton == null)
        {
            singleton = new CurrencyDataCollection();
        }
        return singleton;
    }

    @Override
    public String ToString() {
        String currencyString ="Nazwa|Kod|Współczynnik|Wskaźnik\n";
            for (ICurrency iCurrency : DataCollection) {
            currencyString+=iCurrency.getName()+"|";
            currencyString+=iCurrency.getCode()+"|";
            currencyString+=iCurrency.getFactor()+"|";
            currencyString+=iCurrency.getRate()+"\n";
            }
            return currencyString;
    }

    @Override
    public List<ICurrency> getCurrencyList() {
        return DataCollection;
    }

    @Override
    public ICurrency getCurrencyByCode(ICurrency currency) {
        for(ICurrency iCurrency:DataCollection)
        {
            if(iCurrency.equals(currency))
                return iCurrency;
        }
        return null;
    }
}
