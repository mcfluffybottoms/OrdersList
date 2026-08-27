import { useEffect, useState } from "react";
import { getAllOrders, type Order } from "../api/orders_api";
import { Link } from "react-router-dom";

export default function OrderList() {
    const [orders, setOrders] = useState<Order[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(() => {
        getAllOrders()
            .then((data: Order[]) => {
                setOrders(data);
            })
            .catch((error) => {
                console.error(error);
                setError("Failed to load orders");
            })
            .finally(() => {
                setLoading(false);
            });
    }, []);

    if (loading) {
        return <p>Loading orders...</p>;
    }

    if (error) {
        return <p>{error}</p>;
    }

    return (
        <div>
            <h1>Orders</h1>
            <Link to={"create"}>Add order</Link>
            <hr />
            {orders.length === 0 ? (
                <p>No orders found.</p>
            ) : (
                orders.map((order) => (
                    <div key={order.id}>
                        <Link to={`${order.id}`}>Order #{order.id}</Link>

                        <p>
                            <strong>Sender address:</strong>
                            <br />
                            {order.senderAddress.locality},{" "}
                            {order.senderAddress.streetAddress}
                        </p>

                        <p>
                            <strong>Receiver address:</strong>
                            <br />
                            {order.receiverAddress.locality},{" "}
                            {order.receiverAddress.streetAddress}
                        </p>

                        <p>
                            <strong>Weight:</strong> {order.weight / 1000} kg
                        </p>

                        <p>
                            <strong>Pickup date:</strong>{" "}
                            {new Date(order.pickupDate).toLocaleDateString()}
                        </p>

                        <hr />
                    </div>
                ))
            )}
        </div>
    );
}