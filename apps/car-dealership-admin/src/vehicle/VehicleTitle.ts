import { Vehicle as TVehicle } from "../api/vehicle/Vehicle";

export const VEHICLE_TITLE_FIELD = "id";

export const VehicleTitle = (record: TVehicle): string => {
  return record.id?.toString() || String(record.id);
};
