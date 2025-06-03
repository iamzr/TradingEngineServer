import asyncio
import grpc
import random
import orderbook_pb2
import orderbook_pb2_grpc


async def send_order(stub, security_id, price, quantity, is_buy):
    request = orderbook_pb2.OrderRequest(
        newOrder=orderbook_pb2.NewOrderRequest(
            orderCore=orderbook_pb2.OrderRequestCore(
                securityId=security_id,
                username="test_user"
            ),
            price=price,
            quantity=quantity,
            isBuySide=is_buy
        )
    )
    print(f"Sending order: {request}")
    return await stub.PlaceOrder(request)


async def main():
    async with grpc.aio.insecure_channel('localhost:8000') as channel:
        stub = orderbook_pb2_grpc.OrderbookServiceStub(channel)

        tasks = []
        for _ in range(10):  # Adjust volume here
            price = random.randint(1995, 2005)
            quantity = random.randint(10, 1000)
            is_buy = random.choice([True, False])
            tasks.append(send_order(stub, 0, price, quantity, is_buy))

        responses = await asyncio.gather(*tasks)
        for response in responses:
            print(response)
            
        request = orderbook_pb2.OrderbookSnapshotRequest(securityId=0, depth=0)
        response = await stub.GetOrderbookSnapshot(request)
        print(response)

if __name__ == "__main__":
    asyncio.run(main())
