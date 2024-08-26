import { Sensor } from "../sensor/Sensor";

export type SensorType = {
  createdAt: Date;
  id: string;
  sensors?: Array<Sensor>;
  typeName: string | null;
  updatedAt: Date;
};
