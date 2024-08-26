import { SensorWhereUniqueInput } from "../sensor/SensorWhereUniqueInput";

export type SensorReadingUpdateInput = {
  sensor?: SensorWhereUniqueInput | null;
  timestamp?: Date | null;
  value?: number | null;
};
