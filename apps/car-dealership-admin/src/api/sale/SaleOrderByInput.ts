import { SortOrder } from "../../util/SortOrder";

export type SaleOrderByInput = {
  id?: SortOrder;
  createdAt?: SortOrder;
  updatedAt?: SortOrder;
  date?: SortOrder;
  amount?: SortOrder;
  client?: SortOrder;
  salespersonId?: SortOrder;
  vehicle?: SortOrder;
};
