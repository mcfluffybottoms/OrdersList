import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import OrderList from "./components/OrderList";
import OrderForm from "./components/OrderForm";
import OrderDetails from "./components/OrderDetails";

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Navigate to="/orders" replace />} />
                <Route path="/orders" element={<OrderList />} />
                <Route path="/orders/create" element={<OrderForm />} />
                <Route path="/orders/:id" element={<OrderDetails />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;