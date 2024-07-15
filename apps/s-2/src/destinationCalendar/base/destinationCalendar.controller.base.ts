/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { isRecordNotFoundError } from "../../prisma.util";
import * as errors from "../../errors";
import { Request } from "express";
import { plainToClass } from "class-transformer";
import { ApiNestedQuery } from "../../decorators/api-nested-query.decorator";
import { DestinationCalendarService } from "../destinationCalendar.service";
import { DestinationCalendarCreateInput } from "./DestinationCalendarCreateInput";
import { DestinationCalendar } from "./DestinationCalendar";
import { DestinationCalendarFindManyArgs } from "./DestinationCalendarFindManyArgs";
import { DestinationCalendarWhereUniqueInput } from "./DestinationCalendarWhereUniqueInput";
import { DestinationCalendarUpdateInput } from "./DestinationCalendarUpdateInput";

export class DestinationCalendarControllerBase {
  constructor(protected readonly service: DestinationCalendarService) {}
  @common.Post()
  @swagger.ApiCreatedResponse({ type: DestinationCalendar })
  async createDestinationCalendar(
    @common.Body() data: DestinationCalendarCreateInput
  ): Promise<DestinationCalendar> {
    return await this.service.createDestinationCalendar({
      data: {
        ...data,

        user: data.user
          ? {
              connect: data.user,
            }
          : undefined,

        booking: data.booking
          ? {
              connect: data.booking,
            }
          : undefined,

        eventType: data.eventType
          ? {
              connect: data.eventType,
            }
          : undefined,

        credential: data.credential
          ? {
              connect: data.credential,
            }
          : undefined,
      },
      select: {
        id: true,
        integration: true,
        externalId: true,

        user: {
          select: {
            id: true,
          },
        },

        booking: {
          select: {
            id: true,
          },
        },

        eventType: {
          select: {
            id: true,
          },
        },

        credential: {
          select: {
            id: true,
          },
        },
      },
    });
  }

  @common.Get()
  @swagger.ApiOkResponse({ type: [DestinationCalendar] })
  @ApiNestedQuery(DestinationCalendarFindManyArgs)
  async destinationCalendars(
    @common.Req() request: Request
  ): Promise<DestinationCalendar[]> {
    const args = plainToClass(DestinationCalendarFindManyArgs, request.query);
    return this.service.destinationCalendars({
      ...args,
      select: {
        id: true,
        integration: true,
        externalId: true,

        user: {
          select: {
            id: true,
          },
        },

        booking: {
          select: {
            id: true,
          },
        },

        eventType: {
          select: {
            id: true,
          },
        },

        credential: {
          select: {
            id: true,
          },
        },
      },
    });
  }

  @common.Get("/:id")
  @swagger.ApiOkResponse({ type: DestinationCalendar })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async destinationCalendar(
    @common.Param() params: DestinationCalendarWhereUniqueInput
  ): Promise<DestinationCalendar | null> {
    const result = await this.service.destinationCalendar({
      where: params,
      select: {
        id: true,
        integration: true,
        externalId: true,

        user: {
          select: {
            id: true,
          },
        },

        booking: {
          select: {
            id: true,
          },
        },

        eventType: {
          select: {
            id: true,
          },
        },

        credential: {
          select: {
            id: true,
          },
        },
      },
    });
    if (result === null) {
      throw new errors.NotFoundException(
        `No resource was found for ${JSON.stringify(params)}`
      );
    }
    return result;
  }

  @common.Patch("/:id")
  @swagger.ApiOkResponse({ type: DestinationCalendar })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async updateDestinationCalendar(
    @common.Param() params: DestinationCalendarWhereUniqueInput,
    @common.Body() data: DestinationCalendarUpdateInput
  ): Promise<DestinationCalendar | null> {
    try {
      return await this.service.updateDestinationCalendar({
        where: params,
        data: {
          ...data,

          user: data.user
            ? {
                connect: data.user,
              }
            : undefined,

          booking: data.booking
            ? {
                connect: data.booking,
              }
            : undefined,

          eventType: data.eventType
            ? {
                connect: data.eventType,
              }
            : undefined,

          credential: data.credential
            ? {
                connect: data.credential,
              }
            : undefined,
        },
        select: {
          id: true,
          integration: true,
          externalId: true,

          user: {
            select: {
              id: true,
            },
          },

          booking: {
            select: {
              id: true,
            },
          },

          eventType: {
            select: {
              id: true,
            },
          },

          credential: {
            select: {
              id: true,
            },
          },
        },
      });
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new errors.NotFoundException(
          `No resource was found for ${JSON.stringify(params)}`
        );
      }
      throw error;
    }
  }

  @common.Delete("/:id")
  @swagger.ApiOkResponse({ type: DestinationCalendar })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async deleteDestinationCalendar(
    @common.Param() params: DestinationCalendarWhereUniqueInput
  ): Promise<DestinationCalendar | null> {
    try {
      return await this.service.deleteDestinationCalendar({
        where: params,
        select: {
          id: true,
          integration: true,
          externalId: true,

          user: {
            select: {
              id: true,
            },
          },

          booking: {
            select: {
              id: true,
            },
          },

          eventType: {
            select: {
              id: true,
            },
          },

          credential: {
            select: {
              id: true,
            },
          },
        },
      });
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new errors.NotFoundException(
          `No resource was found for ${JSON.stringify(params)}`
        );
      }
      throw error;
    }
  }
}
