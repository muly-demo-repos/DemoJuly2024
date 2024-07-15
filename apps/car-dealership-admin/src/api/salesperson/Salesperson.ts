import { Sale } from "../sale/Sale";

export type Salesperson = {
  id: string;
  createdAt: Date;
  updatedAt: Date;
  lastName: string | null;
  phone: string | null;
  firstName: string | null;
  email: string | null;
  sales?: Array<Sale>;
};
