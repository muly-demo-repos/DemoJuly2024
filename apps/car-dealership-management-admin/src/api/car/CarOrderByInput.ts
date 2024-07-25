import { SortOrder } from "../../util/SortOrder";

export type CarOrderByInput = {
  id?: SortOrder;
  createdAt?: SortOrder;
  updatedAt?: SortOrder;
  make?: SortOrder;
  year?: SortOrder;
  model?: SortOrder;
  price?: SortOrder;
  licenseNumber?: SortOrder;
};
