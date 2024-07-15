import { Salesperson } from "../salesperson/Salesperson";

export type Sale = {
  id: string;
  createdAt: Date;
  updatedAt: Date;
  date: Date | null;
  amount: number | null;
  client: string | null;
  salesperson?: Salesperson | null;
  vehicle: string | null;
};
