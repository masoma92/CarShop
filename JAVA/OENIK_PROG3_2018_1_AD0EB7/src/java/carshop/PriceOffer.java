/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package carshop;

import java.util.Random;
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
public class PriceOffer {
    
    @XmlElement
    String model;
    
    @XmlElement
    String costumerName;
    
    @XmlElement
    int price;

    public PriceOffer() {
    }

    public PriceOffer(String model,String costumerName, String price) {
        this.costumerName = costumerName;
        this.model = model;
        this.price = Integer.parseInt(price);
        this.price = RandomPriceGenerator();
    }
    
    int RandomPriceGenerator(){
        Random rnd = new Random();
        double output = rnd.nextInt(this.price)+this.price*0.8;
        return (int)output;
    }
    
    public String getModel() {
        return model;
    }

    public void setModel(String model) {
        this.model = model;
    }

    public String getCostumerName() {
        return costumerName;
    }

    public void setCostumerName(String costumerName) {
        this.costumerName = costumerName;
    }

    public int getPrice() {
        return price;
    }

    public void setPrice(int price) {
        this.price = price;
    }
}
