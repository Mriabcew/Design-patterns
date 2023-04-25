package pl.retsuz.view;

import pl.retsuz.collections.IDataCollection;
import pl.retsuz.currency.Currency;
import pl.retsuz.currency.ICurrency;
import pl.retsuz.exchange.IExchange;

import java.util.Scanner;

public class StandardView implements ICurrencyView{
    private IExchange exchange;
    private IDataCollection collection;
    private Scanner scanner = new Scanner(System.in);

    public static StandardView singleton = null;

    private StandardView(){};

    public static StandardView getInstance() {
        if(singleton == null)
        {
            singleton = new StandardView();
        }

        return singleton;
    }

    @Override
    public void setExchange(IExchange exchange) {
        this.exchange = exchange;
    }

    @Override
    public void setDataCollection(IDataCollection collection) {
        this.collection=collection;
    }

    @Override
    public void ViewAll(IDataCollection coll) {
        System.out.println(coll.ToString());
    }

    @Override
    public ICurrency StringToCurrency(String code) {
        ICurrency Currency = new Currency();
        Currency.setCode(code);
        return collection.getCurrencyByCode(Currency);
    }

    @Override
    public ICurrency ChooseCurrency(String label) {
        System.out.println(label);
        String line;
        line = scanner.nextLine();
        return StringToCurrency(line);
    }

    @Override
    public void exchange() {
        ICurrency sourceCurrency = ChooseCurrency("Wprowadz kod waluty do przeliczenia | Insert currency code to change: ");
        ICurrency targetCurrency = ChooseCurrency("Wprowadz kod waluty docelowej | Insert target currency code ");
        System.out.println("Wprowadz ilosc | Insert amount "+sourceCurrency.getName()+":");
        String line;
        double amt;
        line = scanner.nextLine();
        amt = Double.parseDouble(line);

        double tgtAmmount = exchange.exchange(sourceCurrency,targetCurrency,amt);
        System.out.println(amt + " " + sourceCurrency.getName()+ " = " + tgtAmmount + " " + targetCurrency.getName());

    }

    @Override
    public void menu() {
        while(true)
        {
            System.out.println("1.Zamien walute | Change currency");
            System.out.println("2.Wyswietl dostepne waluty | Display available currencies");
            System.out.println("3.Wyjscie | Exit");

            String line = scanner.nextLine();
            int opt = Integer.parseInt(line);
            switch (opt)
            {
                case 1:
                    exchange();
                    break;
                case 2:
                    ViewAll(collection);
                    break;
                case 3:
                    return;
            }

        }

    }
}
