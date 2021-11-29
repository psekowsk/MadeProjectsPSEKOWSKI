using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SauceTesting.SiteElements
{
    public class SauceTestingElements
    {
        //Login Elements
        public static string ReturnUsernameElement() => "user-name";
        public static string ReturnPasswordElement() => "password";
        public static string ReturnLoginButton() => "login-button";

        //Stuff to buy
        public static string ReturnSauceBackpackButton() => "add-to-cart-sauce-labs-backpack";
        public static string ReturnSauceBikeLightButton() => "add-to-cart-sauce-labs-bike-light";
        public static string ReturnSauceBoltTShirtButton() => "add-to-cart-sauce-labs-bolt-t-shirt";
        public static string ReturnSauceFleeceJacketButton() => "add-to-cart-sauce-labs-fleece-jacket";
        public static string ReturnSauceOnesieButton() => "add-to-cart-sauce-labs-onesie";
        public static string ReturnSauceTShirtRedButton() => "add-to-cart-test.allthethings()-t-shirt-(red)";

        //Sort products
        public static string ReturnSauceProductsSort() => "/html/body/div/div/div/div[1]/div[2]/div[2]/span/select";

        //Basket
        public static string ReturnSauceBasket() => "/html/body/div/div/div/div[1]/div[1]/div[3]/a";
        public static string ReturnSauceCheckoutButton() => "checkout"; 
        public static string ReturnSauceContinueShoppingButton() => "continue-shopping";

        //Checkout Your Information
        public static string ReturnSauceFirstNameElement() => "firstName";
        public static string ReturnSauceLastNameElement() => "lastName";
        public static string ReturnSaucePostalCodeElement() => "postalCode";
        public static string ReturnSauceContinueElement() => "continue";
        public static string ReturnSauceCancelElement() => "cancel";

        //Checkout Overview
        public static string ReturnSauceCheckoutOverviewFinishElement() => "finish";
        public static string ReturnSauceCheckoutOverviewCancelElement() => "cancel";
    }
}
