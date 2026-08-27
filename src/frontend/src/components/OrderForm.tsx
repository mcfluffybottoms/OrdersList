import React, { useState } from "react";
import { createOrder, type CreateOrderRequest } from "../api/orders_api";
import { useNavigate } from "react-router-dom";

export default function OrderForm() {
    const [form, setForm] = useState<CreateOrderRequest>({
        senderAddress: {
            locality: "",
            streetAddress: "",
        },
        receiverAddress: {
            locality: "",
            streetAddress: "",
        },
        weight: 0,
        pickupDate: new Date(),
    });

    const navigate = useNavigate();
    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();
        await createOrder(form);
        navigate("/orders");
    }

    return (
        <form onSubmit={handleSubmit}>
            <h1>Create Order</h1>
            <h2>Sender</h2>
            <input
                type="text"
                placeholder="Locality"
                required={true}
                value={form.senderAddress.locality}
                onChange={(e) =>
                    setForm({
                        ...form,
                        senderAddress: {
                            ...form.senderAddress,
                            locality: e.target.value,
                        },
                    })
                }
            />

            <input
                type="text"
                placeholder="Street address"
                required={true}
                value={form.senderAddress.streetAddress}
                onChange={(e) =>
                    setForm({
                        ...form,
                        senderAddress: {
                            ...form.senderAddress,
                            streetAddress: e.target.value,
                        },
                    })
                }
            />

            <h2>Receiver</h2>

            <input
                type="text"
                placeholder="Locality"
                required={true}
                value={form.receiverAddress.locality}
                onChange={(e) =>
                    setForm({
                        ...form,
                        receiverAddress: {
                            ...form.receiverAddress,
                            locality: e.target.value,
                        },
                    })
                }
            />

            <input
                type="text"
                placeholder="Street address"
                required={true}
                value={form.receiverAddress.streetAddress}
                onChange={(e) =>
                    setForm({
                        ...form,
                        receiverAddress: {
                            ...form.receiverAddress,
                            streetAddress: e.target.value,
                        },
                    })
                }
            />

            <h2>Order details</h2>

            <input
                type="number"
                min={1}
                required={true}
                placeholder="Weight (in gramms)"
                onChange={(e) =>
                    setForm({
                        ...form,
                        weight: Number(e.target.value),
                    })
                }
            />

            <input
                type="date"
                required
                min={new Date().toISOString().split("T")[0]}
                value={form.pickupDate.toISOString().split("T")[0]}
                onChange={(e) =>
                    setForm({
                        ...form,
                        pickupDate: new Date(e.target.value),
                    })
                }
            />

            <button type="submit">Create Order</button>
        </form>
    );
}