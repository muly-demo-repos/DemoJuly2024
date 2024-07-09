import * as graphql from "@nestjs/graphql";
import { AnalyticsResults } from "../analytics/AnalyticsResults";
import { AnalyticsService } from "./analytics.service";

export class AnalyticsResolver {
  constructor(protected readonly service: AnalyticsService) {}

  @graphql.Query(() => AnalyticsResults)
  async GetMonthlyAnalytics(
    @graphql.Args()
    args: number
  ): Promise<AnalyticsResults> {
    return this.service.GetMonthlyAnalytics(args);
  }
}
