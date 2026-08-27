import { Link, useParams } from "react-router-dom";

export default function OrderDetails() {
    const { id } = useParams();

    return (
        <div>
            <h1>Order Details</h1>
            <p>Order ID: {id}</p>
            <Link to="/orders">Back to orders</Link>
        </div>
    );
}