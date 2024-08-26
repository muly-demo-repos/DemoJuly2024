import { SensorWhereUniqueInput } from "../sensor/SensorWhereUniqueInput";

export type SensorReadingCreateInput = {
  sensor?: SensorWhereUniqueInput | null;
  timestamp?: Date | null;
  value?: number | null;
};
