package pl.retsuz;

import org.xml.sax.SAXException;
import pl.retsuz.collections.CurrencyDataCollection;
import pl.retsuz.collections.IDataCollection;
import pl.retsuz.collections.providers.IStringCurrencyCollectionProvider;
import pl.retsuz.collections.providers.XMLCurrencyCollectionProvider;
import pl.retsuz.data.IRemoteDataProvider;
import pl.retsuz.data.RemoteDataProvider;
import pl.retsuz.exchange.Exchange;
import pl.retsuz.exchange.IExchange;
import pl.retsuz.view.ExchangeForm;
import pl.retsuz.view.ICurrencyView;
import pl.retsuz.view.StandardView;

import javax.xml.parsers.ParserConfigurationException;
import java.io.IOException;

public class Main {

    static IRemoteDataProvider provider;
    static IDataCollection LastA;
    static IStringCurrencyCollectionProvider xmlProvider;
    static IExchange exchange;
    static StandardView view;
    public static void main(String[] args) {
        provider = RemoteDataProvider.getInstance();
        xmlProvider = new XMLCurrencyCollectionProvider();

        LastA = CurrencyDataCollection.getInstance();
        exchange = Exchange.getInstance();
        view =  StandardView.getInstance();
        try {
            String result = provider.acquireRemoteData("https://www.nbp.pl/kursy/xml/LastA.xml");
            xmlProvider.provide(result,LastA);

            view.setDataCollection(LastA);
            view.setExchange(exchange);
            view.menu();

        } catch (IOException e) {
            e.printStackTrace();
        } catch (SAXException e) {
            e.printStackTrace();
        } catch (ParserConfigurationException e) {
            e.printStackTrace();
        }

    }
}
