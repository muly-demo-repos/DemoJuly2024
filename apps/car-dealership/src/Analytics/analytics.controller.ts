import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as errors from "../errors";
import { AnalyticsService } from "./analytics.service";

@swagger.ApiTags("analytics")
@common.Controller("analytics")
export class AnalyticsController {
  constructor(protected readonly service: AnalyticsService) {}
}
