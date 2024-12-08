import { SortOrder } from "../../util/SortOrder";

export type CarOrderByInput = {
  id?: SortOrder;
  createdAt?: SortOrder;
  updatedAt?: SortOrder;
  licenseNumber?: SortOrder;
  mileage?: SortOrder;
  customerId?: SortOrder;
};
