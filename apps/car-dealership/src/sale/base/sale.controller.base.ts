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
import * as nestAccessControl from "nest-access-control";
import * as defaultAuthGuard from "../../auth/defaultAuth.guard";
import { SaleService } from "../sale.service";
import { AclValidateRequestInterceptor } from "../../interceptors/aclValidateRequest.interceptor";
import { AclFilterResponseInterceptor } from "../../interceptors/aclFilterResponse.interceptor";
import { SaleCreateInput } from "./SaleCreateInput";
import { Sale } from "./Sale";
import { SaleFindManyArgs } from "./SaleFindManyArgs";
import { SaleWhereUniqueInput } from "./SaleWhereUniqueInput";
import { SaleUpdateInput } from "./SaleUpdateInput";

@swagger.ApiBearerAuth()
@common.UseGuards(defaultAuthGuard.DefaultAuthGuard, nestAccessControl.ACGuard)
export class SaleControllerBase {
  constructor(
    protected readonly service: SaleService,
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {}
  @common.UseInterceptors(AclValidateRequestInterceptor)
  @common.Post()
  @swagger.ApiCreatedResponse({ type: Sale })
  @nestAccessControl.UseRoles({
    resource: "Sale",
    action: "create",
    possession: "any",
  })
  @swagger.ApiForbiddenResponse({
    type: errors.ForbiddenException,
  })
  async createSale(@common.Body() data: SaleCreateInput): Promise<Sale> {
    return await this.service.createSale({
      data: {
        ...data,

        salesperson: data.salesperson
          ? {
              connect: data.salesperson,
            }
          : undefined,
      },
      select: {
        id: true,
        createdAt: true,
        updatedAt: true,
        date: true,
        amount: true,
        client: true,

        salesperson: {
          select: {
            id: true,
          },
        },

        vehicle: true,
      },
    });
  }

  @common.UseInterceptors(AclFilterResponseInterceptor)
  @common.Get()
  @swagger.ApiOkResponse({ type: [Sale] })
  @ApiNestedQuery(SaleFindManyArgs)
  @nestAccessControl.UseRoles({
    resource: "Sale",
    action: "read",
    possession: "any",
  })
  @swagger.ApiForbiddenResponse({
    type: errors.ForbiddenException,
  })
  async sales(@common.Req() request: Request): Promise<Sale[]> {
    const args = plainToClass(SaleFindManyArgs, request.query);
    return this.service.sales({
      ...args,
      select: {
        id: true,
        createdAt: true,
        updatedAt: true,
        date: true,
        amount: true,
        client: true,

        salesperson: {
          select: {
            id: true,
          },
        },

        vehicle: true,
      },
    });
  }

  @common.UseInterceptors(AclFilterResponseInterceptor)
  @common.Get("/:id")
  @swagger.ApiOkResponse({ type: Sale })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  @nestAccessControl.UseRoles({
    resource: "Sale",
    action: "read",
    possession: "own",
  })
  @swagger.ApiForbiddenResponse({
    type: errors.ForbiddenException,
  })
  async sale(
    @common.Param() params: SaleWhereUniqueInput
  ): Promise<Sale | null> {
    const result = await this.service.sale({
      where: params,
      select: {
        id: true,
        createdAt: true,
        updatedAt: true,
        date: true,
        amount: true,
        client: true,

        salesperson: {
          select: {
            id: true,
          },
        },

        vehicle: true,
      },
    });
    if (result === null) {
      throw new errors.NotFoundException(
        `No resource was found for ${JSON.stringify(params)}`
      );
    }
    return result;
  }

  @common.UseInterceptors(AclValidateRequestInterceptor)
  @common.Patch("/:id")
  @swagger.ApiOkResponse({ type: Sale })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  @nestAccessControl.UseRoles({
    resource: "Sale",
    action: "update",
    possession: "any",
  })
  @swagger.ApiForbiddenResponse({
    type: errors.ForbiddenException,
  })
  async updateSale(
    @common.Param() params: SaleWhereUniqueInput,
    @common.Body() data: SaleUpdateInput
  ): Promise<Sale | null> {
    try {
      return await this.service.updateSale({
        where: params,
        data: {
          ...data,

          salesperson: data.salesperson
            ? {
                connect: data.salesperson,
              }
            : undefined,
        },
        select: {
          id: true,
          createdAt: true,
          updatedAt: true,
          date: true,
          amount: true,
          client: true,

          salesperson: {
            select: {
              id: true,
            },
          },

          vehicle: true,
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
  @swagger.ApiOkResponse({ type: Sale })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  @nestAccessControl.UseRoles({
    resource: "Sale",
    action: "delete",
    possession: "any",
  })
  @swagger.ApiForbiddenResponse({
    type: errors.ForbiddenException,
  })
  async deleteSale(
    @common.Param() params: SaleWhereUniqueInput
  ): Promise<Sale | null> {
    try {
      return await this.service.deleteSale({
        where: params,
        select: {
          id: true,
          createdAt: true,
          updatedAt: true,
          date: true,
          amount: true,
          client: true,

          salesperson: {
            select: {
              id: true,
            },
          },

          vehicle: true,
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
