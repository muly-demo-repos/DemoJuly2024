import { SortOrder } from "../../util/SortOrder";

export type ProductOrderByInput = {
  id?: SortOrder;
  createdAt?: SortOrder;
  updatedAt?: SortOrder;
  stock?: SortOrder;
  name?: SortOrder;
  description?: SortOrder;
  price?: SortOrder;
};
