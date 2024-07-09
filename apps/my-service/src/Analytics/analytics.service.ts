import { Injectable } from "@nestjs/common";
import { AnalyticsResults } from "../analytics/AnalyticsResults";

@Injectable()
export class AnalyticsService {
  constructor() {}
  async GetMonthlyAnalytics(args: number): Promise<AnalyticsResults> {
    throw new Error("Not implemented");
  }
}
