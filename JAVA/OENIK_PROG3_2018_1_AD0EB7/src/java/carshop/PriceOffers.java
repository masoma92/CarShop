/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package carshop;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Soma
 */
@XmlRootElement
@XmlAccessorType(XmlAccessType.FIELD)
public class PriceOffers {
    
    @XmlElement
    List<PriceOffer> offer;

    public PriceOffers(String brand,String costumerName, String price) {
        this.offer = new ArrayList();
        
        this.offer.add(new PriceOffer(brand,costumerName,price));
        this.offer.add(new PriceOffer(brand,costumerName,price));
        this.offer.add(new PriceOffer(brand,costumerName,price));
        this.offer.add(new PriceOffer(brand,costumerName,price));
        this.offer.add(new PriceOffer(brand,costumerName,price));
        
    }

    public PriceOffers() {
    }
    
    
    
    
    
}
