import * as graphql from "@nestjs/graphql";
import { AnalyticsService } from "./analytics.service";

export class AnalyticsResolver {
  constructor(protected readonly service: AnalyticsService) {}
}
