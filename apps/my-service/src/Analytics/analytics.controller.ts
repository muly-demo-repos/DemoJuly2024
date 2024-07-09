import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as errors from "../errors";
import { AnalyticsService } from "./analytics.service";
import { AnalyticsResults } from "../analytics/AnalyticsResults";

@swagger.ApiTags("analytics")
@common.Controller("analytics")
export class AnalyticsController {
  constructor(protected readonly service: AnalyticsService) {}

  @common.Get("/:id/get-monthly-analytics")
  @swagger.ApiOkResponse({
    type: AnalyticsResults
  })
  @swagger.ApiNotFoundResponse({
    type: errors.NotFoundException
  })
  @swagger.ApiForbiddenResponse({
    type: errors.ForbiddenException
  })
  async GetMonthlyAnalytics(
    @common.Body()
    body: number
  ): Promise<AnalyticsResults> {
        return this.service.GetMonthlyAnalytics(body);
      }
}
