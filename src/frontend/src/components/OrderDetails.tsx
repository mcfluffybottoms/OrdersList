import { Link, useParams } from "react-router-dom";
import { getOrder, type Order } from "../api/orders_api";
import { useEffect, useState } from "react";

export default function OrderDetails() {
    const { id } = useParams();
    const orderId = Number(id);
    const [order, setOrder] = useState<Order>();
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(() => {
        getOrder(orderId)
            .then((data: Order) => {
                setOrder(data);
            })
            .catch((error) => {
                console.error(error);
                setError("Failed to load order.");
            })
            .finally(() => {
                setLoading(false);
            });
    }, []);

    if (loading) {
        return <p>Loading order...</p>;
    }
    if (error) {
        return <p>{error}</p>;
    }
    if (order == null) {
        return <p>Order with id {orderId} not found.</p>;
    }

    return (
        <div>
            <h1>Order #{order.id}</h1>
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
            <Link to="/orders">Back to orders</Link>
        </div>
    );
}