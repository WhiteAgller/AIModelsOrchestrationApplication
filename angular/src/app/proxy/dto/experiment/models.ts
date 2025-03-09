import type { EntityDto } from '@abp/ng.core';

export interface ExperimentGetResponseDto extends EntityDto {
  experimentName?: string;
  experimentId?: string;
}
