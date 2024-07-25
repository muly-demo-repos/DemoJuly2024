import { Car } from "../car/Car";
import { Customer } from "../customer/Customer";
import { Salesperson } from "../salesperson/Salesperson";

export type Sale = {
  id: string;
  createdAt: Date;
  updatedAt: Date;
  date: Date | null;
  totalPrice: number | null;
  car?: Car | null;
  customer?: Customer | null;
  salesperson?: Salesperson | null;
};
