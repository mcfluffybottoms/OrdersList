import { BrowserRouterProps } from "react-router-dom";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import OrderList from "./components/OrderList";
import OrderForm from "./components/OrderForm";
import OrderDetails from "./components/OrderDetails";

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/orders" element={<OrderList />} />
                <Route path="/orders/new" element={<OrderForm />} />
                <Route path="/orders/:id" element={<OrderDetails />} />
            </Routes>
        </BrowserRouter>
    );
}