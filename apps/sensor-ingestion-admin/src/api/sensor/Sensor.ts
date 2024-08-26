import { SensorReading } from "../sensorReading/SensorReading";
import { SensorType } from "../sensorType/SensorType";

export type Sensor = {
  createdAt: Date;
  description: string | null;
  id: string;
  name: string | null;
  sensorReadings?: Array<SensorReading>;
  sensorType?: SensorType | null;
  updatedAt: Date;
};
