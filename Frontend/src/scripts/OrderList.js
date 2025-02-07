import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import axios from "axios";
import config from "./config";

function OrderList() {
	const [orders, setOrders] = useState([]);

	useEffect(() => {
		axios
			.get(`${config.host}/api/orders`)
			.then((response) => {
				setOrders(response.data);
			})
			.catch((error) => {
				console.error("Error fetching orders", error);
			});
	}, []);

	return (
		<div>
			<h2>Список заказов</h2>
			<table border="1" cellPadding="5">
				<thead>
					<tr>
						<th>Номер заказа</th>
						<th>Город отправителя</th>
						<th>Адрес отправителя</th>
						<th>Город получателя</th>
						<th>Адрес получателя</th>
						<th>Вес груза</th>
						<th>Дата забора груза</th>
					</tr>
				</thead>
				<tbody>
					{orders.map((order) => (
						<tr key={order.orderId}>
							<td>
								<Link to={`/order/${order.orderId}`}>
									{order.orderId}
								</Link>
							</td>
							<td>{order.senderCity}</td>
							<td>{order.senderAddress}</td>
							<td>{order.receiverCity}</td>
							<td>{order.receiverAddress}</td>
							<td>{order.cargoWeightKg}</td>
							<td>
								{new Date(
									order.pickupDate
								).toLocaleDateString()}
							</td>
						</tr>
					))}
				</tbody>
			</table>
			<br />
			<Link to="/new">Создать новый заказ</Link>
		</div>
	);
}

export default OrderList;
