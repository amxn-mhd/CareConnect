import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoodHealthComponent } from './good-health.component';

describe('GoodHealthComponent', () => {
  let component: GoodHealthComponent;
  let fixture: ComponentFixture<GoodHealthComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GoodHealthComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GoodHealthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
