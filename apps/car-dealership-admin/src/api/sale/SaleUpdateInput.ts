import { SalespersonWhereUniqueInput } from "../salesperson/SalespersonWhereUniqueInput";

export type SaleUpdateInput = {
  date?: Date | null;
  amount?: number | null;
  client?: string | null;
  salesperson?: SalespersonWhereUniqueInput | null;
  vehicle?: string | null;
};
