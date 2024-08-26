import { SortOrder } from "../../util/SortOrder";

export type SensorOrderByInput = {
  createdAt?: SortOrder;
  description?: SortOrder;
  id?: SortOrder;
  name?: SortOrder;
  sensorTypeId?: SortOrder;
  updatedAt?: SortOrder;
};
