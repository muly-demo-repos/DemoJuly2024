import { SensorReadingWhereInput } from "./SensorReadingWhereInput";
import { SensorReadingOrderByInput } from "./SensorReadingOrderByInput";

export type SensorReadingFindManyArgs = {
  where?: SensorReadingWhereInput;
  orderBy?: Array<SensorReadingOrderByInput>;
  skip?: number;
  take?: number;
};
