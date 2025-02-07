import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import config from "./config";

function OrderForm() {
	const [order, setOrder] = useState({
		senderCity: "",
		senderAddress: "",
		receiverCity: "",
		receiverAddress: "",
		cargoWeightKg: "",
		pickupDate: "",
	});

	const navigate = useNavigate();

	const handleChange = (e) => {
		setOrder({ ...order, [e.target.name]: e.target.value });
	};

	const handleSubmit = (e) => {
		e.preventDefault();
		axios
			.post(`${config.host}/api/orders`, order)
			.then((_) => {
				navigate("/");
			})
			.catch((error) => {
				console.error("Error creating order", error);
			});
	};

	return (
		<div>
			<h2>Создать новый заказ</h2>
			<form onSubmit={handleSubmit}>
				<div>
					<label>Город отправителя:</label>
					<input
						type="text"
						name="senderCity"
						value={order.senderCity}
						onChange={handleChange}
						required
					/>
				</div>
				<div>
					<label>Адрес отправителя:</label>
					<input
						type="text"
						name="senderAddress"
						value={order.senderAddress}
						onChange={handleChange}
						required
					/>
				</div>
				<div>
					<label>Город получателя:</label>
					<input
						type="text"
						name="receiverCity"
						value={order.receiverCity}
						onChange={handleChange}
						required
					/>
				</div>
				<div>
					<label>Адрес получателя:</label>
					<input
						type="text"
						name="receiverAddress"
						value={order.receiverAddress}
						onChange={handleChange}
						required
					/>
				</div>
				<div>
					<label>Вес груза:</label>
					<input
						type="number"
						step="0.01"
						name="cargoWeightKg"
						value={order.cargoWeightKg}
						onChange={handleChange}
						required
					/>
				</div>
				<div>
					<label>Дата забора груза:</label>
					<input
						type="date"
						name="pickupDate"
						value={order.pickupDate}
						onChange={handleChange}
						required
					/>
				</div>
				<button type="submit">Создать заказ</button>
			</form>
		</div>
	);
}

export default OrderForm;
