import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import OrderList from "./OrderList";
import OrderForm from "./OrderForm";
import OrderDetails from "./OrderDetails";

function App() {
	return (
		<Router>
			<div>
				<Routes>
					<Route path="/" element={<OrderList />} />
					<Route path="/new" element={<OrderForm />} />
					<Route path="/order/:id" element={<OrderDetails />} />
				</Routes>
			</div>
		</Router>
	);
}

export default App;
