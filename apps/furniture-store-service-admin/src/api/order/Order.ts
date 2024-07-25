import { Customer } from "../customer/Customer";
import { OrderItem } from "../orderItem/OrderItem";

export type Order = {
  id: string;
  createdAt: Date;
  updatedAt: Date;
  date: Date | null;
  status?: "Option1" | null;
  customer?: Customer | null;
  orderItems?: Array<OrderItem>;
};
