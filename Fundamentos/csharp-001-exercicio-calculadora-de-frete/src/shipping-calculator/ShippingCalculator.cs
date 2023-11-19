using System;

namespace ShippingCalculator;

public class ShippingCalculator
{
    /// <summary>
    /// This function evaluates the order price passed as an input parameter and returns the shipping price following the exercise's logic
    /// </summary>
    /// <param name="orderPrice"> A value of type double, the order price </param>
    /// <returns>The shipping price value (integer type), following the exercise logic </returns>
    /// <exception cref="ArgumentException">If the order price be equal to or less than zero</exception>

    // 1 - Calcular o Frete por preço do pedido na função `CalculateShippingPrice`
    public double calculateShippingPrice(double orderPrice)
    {

        double shippingPrice = 00.00;

        switch (orderPrice)
        {
            case <= 50:
                shippingPrice = 25.00;
                break;
            case <= 100:
                shippingPrice = 20.00;
                break;
            case <= 200:
                shippingPrice = 15.00;
                break;
        }

        return shippingPrice;
    }

    // 2 - Calcular o Frete por peso na função `CalculateShippingWeight`
    public double calculateShippingWeight(double weight)
    {

        double shippingPrice;

        switch (weight)
        {
            case <= 1.5:
                shippingPrice = 3.80;
                break;
            case <= 3.5:
                shippingPrice = 5.70;
                break;
            case <= 7.00:
                shippingPrice = 7.20;
                break;
            case <= 10.00:
                shippingPrice = 9.40;
                break;
            default:
                shippingPrice = weight * 1.9;
                break;
        }

        return shippingPrice;
    }

    // 3 - Calcular o Frete final na função `CalculateShipping`
    public double calculateShipping(double orderPrice, double weight)
    {
        double shippingByWeight = calculateShippingWeight(weight);
        double shippingByPrice = calculateShippingPrice(orderPrice);
        double finalShipping = shippingByPrice + shippingByWeight;

        if (finalShipping > 45)
        {
            finalShipping = finalShipping * (1 - 0.15);
        }

        return finalShipping;
    }

    // 4 - Calcular o Frete final para um array de preços e um array de pesos na função `CalculateShippingFromArray`
    public double calculateShippingFromArray(double[] itemPrices, double[] itemWeights)
    {
        // throw new NotImplementedException();

        double shippingByPrice = 0;
        double shippingByWeight = 0;

        foreach (double prices in itemPrices)
            shippingByPrice += prices;


        foreach (double weight in itemWeights)
            shippingByWeight += weight;

        double total = calculateShipping(shippingByPrice, shippingByWeight);

        return total;
    }

}