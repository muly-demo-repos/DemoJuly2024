import { SensorTypeWhereInput } from "./SensorTypeWhereInput";
import { SensorTypeOrderByInput } from "./SensorTypeOrderByInput";

export type SensorTypeFindManyArgs = {
  where?: SensorTypeWhereInput;
  orderBy?: Array<SensorTypeOrderByInput>;
  skip?: number;
  take?: number;
};
