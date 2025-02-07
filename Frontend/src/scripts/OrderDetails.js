import React, { useEffect, useState } from "react";
import axios from "axios";
import { useParams, Link } from "react-router-dom";

function OrderDetails() {
	const { id } = useParams();
	const [order, setOrder] = useState(null);

	useEffect(() => {
		axios
			.get(`http://backend:5000/api/orders/${id}`)
			.then((response) => {
				setOrder(response.data);
			})
			.catch((error) => {
				console.error("Error fetching order details", error);
			});
	}, [id]);

	if (!order) return <div>Загрузка...</div>;

	return (
		<div>
			<h2>Детали заказа</h2>
			<p>
				<strong>Номер заказа:</strong> {order.orderId}
			</p>
			<p>
				<strong>Город отправителя:</strong> {order.senderCity}
			</p>
			<p>
				<strong>Адрес отправителя:</strong> {order.senderAddress}
			</p>
			<p>
				<strong>Город получателя:</strong> {order.receiverCity}
			</p>
			<p>
				<strong>Адрес получателя:</strong> {order.receiverAddress}
			</p>
			<p>
				<strong>Вес груза:</strong> {order.cargoWeightKg}
			</p>
			<p>
				<strong>Дата забора груза:</strong>{" "}
				{new Date(order.pickupDate).toLocaleDateString()}
			</p>
			<Link to="/">Назад к списку заказов</Link>
		</div>
	);
}

export default OrderDetails;
