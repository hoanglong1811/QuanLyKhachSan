<!-- File: Reports.vue -->
<template>
  <div>
    <Navbar />
    <div class="page-container">
      <div class="content-wrapper">
        <div class="content-container">
          <!-- Header Section -->
          <div class="header-section">
            <div class="header-left">
              <h1 class="page-title">Báo cáo doanh thu</h1>
              <p class="subtitle">Thống kê và phân tích doanh thu khách sạn</p>
            </div>
            <div class="header-right">
              <div class="date-filter">
                <select v-model="selectedPeriod" class="period-select">
                  <option value="today">Hôm nay</option>
                  <option value="week">Tuần này</option>
                  <option value="month">Tháng này</option>
                  <option value="year">Năm nay</option>
                  <option value="custom">Tùy chỉnh</option>
                </select>
                <div v-if="selectedPeriod === 'custom'" class="custom-date">
                  <input type="date" v-model="startDate" class="date-input">
                  <span>đến</span>
                  <input type="date" v-model="endDate" class="date-input">
                </div>
              </div>
            </div>
          </div>

          <!-- Summary Cards -->
          <div class="summary-cards">
            <div class="summary-card">
              <div class="card-icon revenue">
                <i class="fas fa-dollar-sign"></i>
              </div>
              <div class="card-content">
                <h3>Tổng doanh thu</h3>
                <p class="amount">{{ formatCurrency(totalRevenue) }}</p>
                <span class="trend" :class="{ 'up': revenueTrend > 0, 'down': revenueTrend < 0 }">
                  <i :class="revenueTrend > 0 ? 'fas fa-arrow-up' : 'fas fa-arrow-down'"></i>
                  {{ Math.abs(revenueTrend) }}% so với kỳ trước
                </span>
              </div>
            </div>

            <div class="summary-card">
              <div class="card-icon bookings">
                <i class="fas fa-calendar-check"></i>
              </div>
              <div class="card-content">
                <h3>Tổng đặt phòng</h3>
                <p class="amount">{{ totalBookings }}</p>
                <span class="trend" :class="{ 'up': bookingsTrend > 0, 'down': bookingsTrend < 0 }">
                  <i :class="bookingsTrend > 0 ? 'fas fa-arrow-up' : 'fas fa-arrow-down'"></i>
                  {{ Math.abs(bookingsTrend) }}% so với kỳ trước
                </span>
              </div>
            </div>

            <div class="summary-card">
              <div class="card-icon services">
                <i class="fas fa-concierge-bell"></i>
              </div>
              <div class="card-content">
                <h3>Doanh thu dịch vụ</h3>
                <p class="amount">{{ formatCurrency(serviceRevenue) }}</p>
                <span class="trend" :class="{ 'up': serviceTrend > 0, 'down': serviceTrend < 0 }">
                  <i :class="serviceTrend > 0 ? 'fas fa-arrow-up' : 'fas fa-arrow-down'"></i>
                  {{ Math.abs(serviceTrend) }}% so với kỳ trước
                </span>
              </div>
            </div>

            <div class="summary-card">
              <div class="card-icon occupancy">
                <i class="fas fa-bed"></i>
              </div>
              <div class="card-content">
                <h3>Tỷ lệ lấp đầy</h3>
                <p class="amount">{{ occupancyRate }}%</p>
                <span class="trend" :class="{ 'up': occupancyTrend > 0, 'down': occupancyTrend < 0 }">
                  <i :class="occupancyTrend > 0 ? 'fas fa-arrow-up' : 'fas fa-arrow-down'"></i>
                  {{ Math.abs(occupancyTrend) }}% so với kỳ trước
                </span>
              </div>
            </div>
          </div>

          <!-- Charts Section -->
          <div class="charts-section">
            <div class="chart-container">
              <h3 class="chart-title">Doanh thu theo thời gian</h3>
              <div class="chart-wrapper">
                <!-- Revenue Chart will be rendered here -->
                <canvas ref="revenueChart"></canvas>
              </div>
            </div>

            <div class="chart-container">
              <h3 class="chart-title">Phân bố doanh thu theo loại phòng</h3>
              <div class="chart-wrapper">
                <!-- Room Type Chart will be rendered here -->
                <canvas ref="roomTypeChart"></canvas>
              </div>
            </div>
          </div>

          <!-- Detailed Statistics -->
          <div class="detailed-stats">
            <h3 class="section-title">Thống kê chi tiết</h3>
            <div class="table-responsive">
              <table class="stats-table">
                <thead>
                  <tr>
                    <th>Loại phòng</th>
                    <th>Số đêm</th>
                    <th>Doanh thu</th>
                    <th>Tỷ lệ</th>
                    <th>Xu hướng</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="room in roomStats" :key="room.type">
                    <td>{{ room.type }}</td>
                    <td>{{ room.nights }}</td>
                    <td>{{ formatCurrency(room.revenue) }}</td>
                    <td>{{ room.percentage }}%</td>
                    <td>
                      <span class="trend" :class="{ 'up': room.trend > 0, 'down': room.trend < 0 }">
                        <i :class="room.trend > 0 ? 'fas fa-arrow-up' : 'fas fa-arrow-down'"></i>
                        {{ Math.abs(room.trend) }}%
                      </span>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from '@/components/navbar.vue';
import Chart from 'chart.js/auto';

export default {
  name: 'Reports',
  components: {
    Navbar
  },
  data() {
    return {
      selectedPeriod: 'month',
      startDate: '',
      endDate: '',
      // Sample data - replace with actual data from API
      totalRevenue: 150000000,
      revenueTrend: 12.5,
      totalBookings: 156,
      bookingsTrend: 8.3,
      serviceRevenue: 45000000,
      serviceTrend: 15.2,
      occupancyRate: 85,
      occupancyTrend: 5.7,
      roomStats: [
        {
          type: 'Phòng Deluxe',
          nights: 245,
          revenue: 73500000,
          percentage: 35,
          trend: 10.5
        },
        {
          type: 'Phòng Suite',
          nights: 180,
          revenue: 54000000,
          percentage: 25,
          trend: 8.2
        },
        {
          type: 'Phòng Standard',
          nights: 320,
          revenue: 48000000,
          percentage: 30,
          trend: -5.3
        },
        {
          type: 'Phòng Family',
          nights: 95,
          revenue: 28500000,
          percentage: 10,
          trend: 15.7
        }
      ]
    };
  },
  mounted() {
    this.initCharts();
  },
  methods: {
    formatCurrency(value) {
      return new Intl.NumberFormat('vi-VN', {
        style: 'currency',
        currency: 'VND'
      }).format(value);
    },
    initCharts() {
      // Revenue Chart
      const revenueCtx = this.$refs.revenueChart.getContext('2d');
      new Chart(revenueCtx, {
        type: 'line',
        data: {
          labels: ['T1', 'T2', 'T3', 'T4', 'T5', 'T6', 'T7', 'T8', 'T9', 'T10', 'T11', 'T12'],
          datasets: [{
            label: 'Doanh thu',
            data: [65, 59, 80, 81, 56, 55, 40, 45, 60, 75, 85, 90],
            borderColor: '#3b82f6',
            tension: 0.4,
            fill: true,
            backgroundColor: 'rgba(59, 130, 246, 0.1)'
          }]
        },
        options: {
          responsive: true,
          maintainAspectRatio: false,
          plugins: {
            legend: {
              display: false
            }
          },
          scales: {
            y: {
              beginAtZero: true,
              grid: {
                color: 'rgba(0, 0, 0, 0.1)'
              }
            },
            x: {
              grid: {
                display: false
              }
            }
          }
        }
      });

      // Room Type Chart
      const roomTypeCtx = this.$refs.roomTypeChart.getContext('2d');
      new Chart(roomTypeCtx, {
        type: 'doughnut',
        data: {
          labels: ['Deluxe', 'Suite', 'Standard', 'Family'],
          datasets: [{
            data: [35, 25, 30, 10],
            backgroundColor: [
              '#3b82f6',
              '#10b981',
              '#f59e0b',
              '#ef4444'
            ]
          }]
        },
        options: {
          responsive: true,
          maintainAspectRatio: false,
          plugins: {
            legend: {
              position: 'right'
            }
          }
        }
      });
    }
  }
};
</script>

<style scoped>
.page-container {
  min-height: 100vh;
  background-color: #f3f4f6;
  padding: 2rem;
}

.content-wrapper {
  max-width: 1400px;
  margin: 0 auto;
}

.content-container {
  background-color: white;
  border-radius: 1rem;
  box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1);
  padding: 2rem;
}

.header-section {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 2rem;
  padding-bottom: 1.5rem;
  border-bottom: 1px solid #e5e7eb;
}

.header-left {
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
}

.page-title {
  font-size: 1.875rem;
  font-weight: 700;
  color: #111827;
  margin: 0;
}

.subtitle {
  color: #6b7280;
  font-size: 0.975rem;
}

.header-right {
  display: flex;
  gap: 1rem;
}

.date-filter {
  display: flex;
  align-items: center;
  gap: 1rem;
}

.period-select {
  padding: 0.5rem 1rem;
  border: 1px solid #e5e7eb;
  border-radius: 0.5rem;
  background-color: white;
  color: #374151;
  font-size: 0.875rem;
}

.custom-date {
  display: flex;
  align-items: center;
  gap: 0.5rem;
}

.date-input {
  padding: 0.5rem;
  border: 1px solid #e5e7eb;
  border-radius: 0.5rem;
  font-size: 0.875rem;
}

.summary-cards {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  gap: 1.5rem;
  margin-bottom: 2rem;
}

.summary-card {
  background-color: white;
  border-radius: 1rem;
  padding: 1.5rem;
  display: flex;
  gap: 1rem;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
}

.card-icon {
  width: 48px;
  height: 48px;
  border-radius: 0.75rem;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 1.5rem;
}

.card-icon.revenue {
  background-color: #dbeafe;
  color: #3b82f6;
}

.card-icon.bookings {
  background-color: #dcfce7;
  color: #10b981;
}

.card-icon.services {
  background-color: #fef3c7;
  color: #f59e0b;
}

.card-icon.occupancy {
  background-color: #fee2e2;
  color: #ef4444;
}

.card-content {
  flex: 1;
}

.card-content h3 {
  font-size: 0.875rem;
  color: #6b7280;
  margin: 0 0 0.5rem 0;
}

.amount {
  font-size: 1.5rem;
  font-weight: 600;
  color: #111827;
  margin: 0 0 0.5rem 0;
}

.trend {
  font-size: 0.875rem;
  display: flex;
  align-items: center;
  gap: 0.25rem;
}

.trend.up {
  color: #10b981;
}

.trend.down {
  color: #ef4444;
}

.charts-section {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 1.5rem;
  margin-bottom: 2rem;
}

.chart-container {
  background-color: white;
  border-radius: 1rem;
  padding: 1.5rem;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
}

.chart-title {
  font-size: 1.125rem;
  font-weight: 600;
  color: #111827;
  margin: 0 0 1rem 0;
}

.chart-wrapper {
  height: 300px;
}

.detailed-stats {
  background-color: white;
  border-radius: 1rem;
  padding: 1.5rem;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
}

.section-title {
  font-size: 1.125rem;
  font-weight: 600;
  color: #111827;
  margin: 0 0 1rem 0;
}

.table-responsive {
  overflow-x: auto;
}

.stats-table {
  width: 100%;
  border-collapse: collapse;
}

.stats-table th,
.stats-table td {
  padding: 1rem;
  text-align: left;
  border-bottom: 1px solid #e5e7eb;
}

.stats-table th {
  font-weight: 600;
  color: #374151;
  background-color: #f9fafb;
}

.stats-table td {
  color: #4b5563;
}

@media (max-width: 1200px) {
  .summary-cards {
    grid-template-columns: repeat(2, 1fr);
  }
}

@media (max-width: 768px) {
  .page-container {
    padding: 1rem;
  }

  .content-container {
    padding: 1rem;
  }

  .header-section {
    flex-direction: column;
    align-items: flex-start;
    gap: 1rem;
  }

  .charts-section {
    grid-template-columns: 1fr;
  }

  .summary-cards {
    grid-template-columns: 1fr;
  }
}
</style> 