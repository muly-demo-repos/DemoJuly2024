import { SalespersonWhereUniqueInput } from "../salesperson/SalespersonWhereUniqueInput";

export type SaleCreateInput = {
  date?: Date | null;
  amount?: number | null;
  client?: string | null;
  salesperson?: SalespersonWhereUniqueInput | null;
  vehicle?: string | null;
};
