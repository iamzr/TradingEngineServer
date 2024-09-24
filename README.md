# TradingEngineServer

## Overview
This is a C#-based project aimed at building a trading engine that will handle order matching and trade execution. As of now, the project includes a fully functional OrderBook implementation. The next step is to develop a matching engine that will pair buy and sell orders efficiently.

This project is designed as the core component for a trading system, eventually allowing simulated or live market trading.

## Features (Current)
- Order Book: A basic order book implementation that:
- Supports limit orders (buy and sell).
- Allows for order cancellation.
- Keeps track of best bid and ask prices.
- Stores buy and sell orders in separate queues sorted by price and time.

## Planned Features
- Matching Engine: The matching engine will soon be added to match buy and sell orders based on price-time priority.
- Order Types: Additional order types such as market orders, stop-loss, and more complex conditional orders are planned.
- Risk Management: Basic risk management features such as position limits, exposure control, and margin calculations will be incorporated in future iterations.

## Installation
### Prerequisites
- .NET 7 SDK: The project requires .NET 7. You can download it from the official .NET website.
- A development environment like Visual Studio or VS Code (or any text editor).

### Setup
1. Clone this repository.
2. Open the project in Visual Studio or your preferred C# IDE.
3. Build the project to restore dependencies and compile the code.
4. (Optional) Run tests to ensure everything is working as expected.

```bash
dotnet test
```