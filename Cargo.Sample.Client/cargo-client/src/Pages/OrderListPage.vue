<template>
  <div class="orders-container">
    <div class="page-header">
      <h1>My Orders</h1>
      <p class="subtitle">Customer's placed orders and item details</p>
    </div>

    <div class="summary-cards">
      <div class="summary-card">
        <div class="card-content">
          <span class="card-label">Total Orders</span>
          <span class="card-value">{{ orders?.length }}</span>
        </div>
      </div>
      <div class="summary-card">
        <div class="card-content">
          <span class="card-label">Total Items</span>
          <span class="card-value">{{ totalItems }}</span>
        </div>
      </div>
      <div class="summary-card">
        <div class="card-content">
          <span class="card-label">Grand Total</span>
          <span class="card-value">{{ formatCurrency(grandTotal ?? 0) }}</span>
        </div>
      </div>
    </div>

    <div class="orders-list">
      <div 
        v-for="(order, index) in orders" 
        :key="order.orderId" 
        class="order-card"
      >
        <div class="order-header" @click="toggleOrder(index)">
          <div class="order-info">
            <div class="city-avatar">
              {{ getCityInitials(order.cityName) }}
            </div>
            <div class="order-details">
              <h3 class="order-id">Order #{{ getShortId(order.orderId) }}</h3> //bir kod oluşturup kod yazdır
              <p class="order-location">
                {{ order.cityName }} / {{ order.districtName }} · {{ order.detail }}
              </p>
            </div>
          </div>
          <div class="order-summary">
            <span class="status-badge" :class="getStatusClass(order.orderStatus)">
              {{ getStatusLabel(order.orderStatus) }}
            </span>
            <div class="order-totals">
              <span class="items-count">{{ order.productItems.length }} items</span>
              <span class="total-amount">{{ formatCurrency(calculateOrderTotal(order)) }}</span>
            </div>
            <button class="toggle-btn" :class="{ 'expanded': expandedOrders.includes(index) }">
              <svg viewBox="0 0 24 24" class="chevron-icon">
                <path d="M6 9l6 6 6-6" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
              </svg>
            </button>
          </div>
        </div>

        <div v-if="expandedOrders.includes(index)" class="order-body">
          <div class="products-table">
            <div class="table-header">
              <div class="header-cell product-col">Product</div>
              <div class="header-cell qty-col">Qty</div>
              <div class="header-cell price-col">Price</div>
              <div class="header-cell total-col">Total</div>
            </div>
            <div class="table-body">
              <div 
                v-for="item in order.productItems" 
                :key="item.id" 
                class="table-row"
              >
                <div class="table-cell product-cell">
                  <div class="product-info">
                    <div class="product-icon">📦</div>
                    <span class="product-name">{{ item.name }}</span>
                  </div>
                </div>
                <div class="table-cell qty-cell">{{ item.quantity }}</div>
                <div class="table-cell price-cell">{{ formatCurrency(item.price) }}</div>
                <div class="table-cell total-cell">{{ formatCurrency(item.price * item.quantity) }}</div>
              </div>
            </div>
            <div class="table-footer">
              <div class="footer-total">
                <span class="total-label">Order Total:</span>
                <span class="total-value">{{ formatCurrency(calculateOrderTotal(order)) }}</span>
              </div>
            </div>
          </div>

          <div class="order-actions">
            <button class="action-btn secondary" @click="copyOrderId(order.orderId)">
              Copy Order ID
            </button>
            <button class="action-btn primary" @click="trackOrder(order.orderId)">
              Track Order
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { EndpointOrder } from '@/Request/EndpointOrder'
import { ref, computed, onMounted } from 'vue'

export interface ProductItem {
  id: string
  name: string
  quantity: number
  price: number
}

export interface Order {
  orderId: string
  cityName: string
  districtName: string
  detail: string
  orderStatus: number
  productItems: ProductItem[]
}

const orders = ref<Order[]>()

const expandedOrders = ref<number[]>([])


onMounted(async()=>{
  var endpoint = EndpointOrder.GetEndpointOrder()

  const user= localStorage.getItem('login')
  const jsonUser = JSON.parse(user!) //bunu pinia'ya çek
  const data = await endpoint.GetAllOrderByCustomerId(jsonUser.userId)

  orders.value = data.data ?? [];
})

const totalItems = computed(() => {
  return orders.value?.reduce((total, order) => {
    return total + order.productItems.reduce((sum, item) => sum + item.quantity, 0)
  }, 0)
})

const grandTotal = computed(() => {
  return orders.value?.reduce((total, order) => total + calculateOrderTotal(order), 0)
})

const formatCurrency = (amount: number): string => {
  return new Intl.NumberFormat('tr-TR', {
    style: 'currency',
    currency: 'TRY',
    maximumFractionDigits: 0
  }).format(amount)
}

const getCityInitials = (cityName: string): string => {
  return cityName.substring(0, 3).toUpperCase()
}

const getShortId = (id: string): string => {
  return `${id.substring(0, 8)}...${id.substring(id.length - 4)}`
}

const calculateOrderTotal = (order: Order): number => {
  return order.productItems.reduce((total, item) => total + (item.price * item.quantity), 0)
}

const getStatusLabel = (status: number): string => {
  const statusMap: Record<number, string> = {
    1: 'Picked Up',
    2: 'In Transit',
    3: 'At Distribution Center',
    4: 'Out For Delivery',
    5: 'Delivery',
    6: 'Cancelled',
    7: 'Rejected',
    8: 'Returned',
    9: 'Accepted',
    10: 'Processing'
  }
  return statusMap[status] || `Status ${status}`
}

const getStatusClass = (status: number): string => {
  const classMap: Record<number, string> = {
    1: 'status-pickedup',
    2: 'status-inTransit',
    3: 'status-atDistributionCenter',
    4: 'status-outForDelivery',
    5: 'status-delivery',
    6: 'status-cancelled',
    7: 'status-rejected',
    8:'status-returned',
    9:'status-accepted',
    10:'status-processing'
  }
  return classMap[status] || 'status-unknown'
}

const toggleOrder = (index: number) => {
  const expandedIndex = expandedOrders.value.indexOf(index)

  console.log(expandedIndex)
  if (expandedIndex > -1) {
    expandedOrders.value.splice(expandedIndex, 1)
  } else {
    expandedOrders.value.push(index)
  }
}

const copyOrderId = async (orderId: string) => {
  try {
    await navigator.clipboard.writeText(orderId)
    alert('Order ID copied to clipboard!')
  } catch (err) {
    console.error('Failed to copy order ID:', err)
  }
}

const trackOrder = (orderId: string) => {
  alert(`Tracking order: ${getShortId(orderId)}`)
}
</script>

<style scoped>
.orders-container {
  max-width: 1200px;
  margin: 0 auto;
  padding: 20px;
  font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif;
  background: linear-gradient(135deg, #f5f7fa 0%, #c3cfe2 100%);
  min-height: 100vh;
}

.page-header {
  margin-bottom: 30px;
  text-align: center;
}

.page-header h1 {
  font-size: 2.5rem;
  color: #2d3748;
  margin-bottom: 8px;
  font-weight: 700;
}

.subtitle {
  color: #718096;
  font-size: 1.1rem;
  margin: 0;
}

.summary-cards {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
  gap: 20px;
  margin-bottom: 30px;
}

.summary-card {
  background: white;
  border-radius: 16px;
  padding: 24px;
  box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1);
  border: 1px solid #e2e8f0;
  transition: transform 0.2s ease, box-shadow 0.2s ease;
}

.summary-card:hover {
  transform: translateY(-2px);
  box-shadow: 0 8px 25px -5px rgba(0, 0, 0, 0.1);
}

.card-content {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.card-label {
  font-size: 0.9rem;
  color: #718096;
  font-weight: 500;
}

.card-value {
  font-size: 1.8rem;
  font-weight: 700;
  color: #2d3748;
}

.orders-list {
  display: flex;
  flex-direction: column;
  gap: 16px;
}

.order-card {
  background: white;
  border-radius: 16px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  border: 1px solid #e2e8f0;
  overflow: hidden;
  transition: all 0.2s ease;
}

.order-card:hover {
  transform: translateY(-1px);
  box-shadow: 0 8px 25px -5px rgba(0, 0, 0, 0.1);
}

.order-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 24px;
  cursor: pointer;
  transition: background-color 0.2s ease;
}

.order-header:hover {
  background-color: #f7fafc;
}

.order-info {
  display: flex;
  align-items: center;
  gap: 16px;
}

.city-avatar {
  width: 48px;
  height: 48px;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  color: white;
  border-radius: 12px;
  display: flex;
  align-items: center;
  justify-content: center;
  font-weight: 700;
  font-size: 0.9rem;
}

.order-details h3 {
  margin: 0;
  color: #2d3748;
  font-size: 1.1rem;
  font-weight: 600;
}

.order-location {
  margin: 4px 0 0 0;
  color: #718096;
  font-size: 0.9rem;
}

.order-summary {
  display: flex;
  align-items: center;
  gap: 16px;
}

.status-badge {
  padding: 6px 12px;
  border-radius: 20px;
  font-size: 0.75rem;
  font-weight: 600;
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.status-placed {
  background: #ebf8ff;
  color: #2b6cb0;
}

.status-processing {
  background: #fef5e7;
  color: #c05621;
}

.status-shipped {
  background: #f0fff4;
  color: #2f855a;
}

.status-delivery {
  background: #e6fffa;
  color: #319795;
}

.status-delivered {
  background: #f0fff4;
  color: #38a169;
}

.status-cancelled {
  background: #fed7d7;
  color: #c53030;
}

.order-totals {
  display: flex;
  flex-direction: column;
  align-items: flex-end;
  gap: 4px;
}

.items-count {
  font-size: 0.8rem;
  color: #718096;
  background: #f7fafc;
  padding: 4px 8px;
  border-radius: 12px;
}

.total-amount {
  font-weight: 700;
  color: #2d3748;
  font-size: 1.1rem;
}

.toggle-btn {
  background: none;
  border: 2px solid #e2e8f0;
  border-radius: 8px;
  width: 36px;
  height: 36px;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
  transition: all 0.2s ease;
}

.toggle-btn:hover {
  border-color: #cbd5e0;
  background: #f7fafc;
}

.chevron-icon {
  width: 16px;
  height: 16px;
  transition: transform 0.2s ease;
}

.toggle-btn.expanded .chevron-icon {
  transform: rotate(180deg);
}

.order-body {
  border-top: 1px solid #e2e8f0;
  background: #f7fafc;
  padding: 24px;
}

.products-table {
  background: white;
  border-radius: 12px;
  overflow: hidden;
  margin-bottom: 20px;
  border: 1px solid #e2e8f0;
}

.table-header {
  display: grid;
  grid-template-columns: 2fr 1fr 1fr 1fr;
  background: #f7fafc;
  padding: 16px 20px;
  border-bottom: 1px solid #e2e8f0;
}

.header-cell {
  font-weight: 600;
  color: #4a5568;
  font-size: 0.8rem;
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.table-body {
  display: flex;
  flex-direction: column;
}

.table-row {
  display: grid;
  grid-template-columns: 2fr 1fr 1fr 1fr;
  padding: 16px 20px;
  border-bottom: 1px solid #f1f5f9;
  align-items: center;
}

.table-row:last-child {
  border-bottom: none;
}

.product-cell {
  display: flex;
  align-items: center;
}

.product-info {
  display: flex;
  align-items: center;
  gap: 12px;
}

.product-icon {
  width: 32px;
  height: 32px;
  background: #f7fafc;
  border-radius: 8px;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 1.2rem;
}

.product-name {
  font-weight: 500;
  color: #2d3748;
}

.qty-cell, .price-cell, .total-cell {
  font-variant-numeric: tabular-nums;
  font-weight: 500;
}

.total-cell {
  text-align: right;
  font-weight: 600;
}

.table-footer {
  background: #f7fafc;
  padding: 16px 20px;
  border-top: 1px solid #e2e8f0;
}

.footer-total {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.total-label {
  font-weight: 600;
  color: #4a5568;
}

.total-value {
  font-weight: 700;
  font-size: 1.2rem;
  color: #2d3748;
}

.order-actions {
  display: flex;
  gap: 12px;
  justify-content: flex-end;
}

.action-btn {
  padding: 10px 20px;
  border-radius: 8px;
  border: none;
  font-weight: 500;
  cursor: pointer;
  transition: all 0.2s ease;
}

.action-btn.secondary {
  background: white;
  color: #4a5568;
  border: 1px solid #e2e8f0;
}

.action-btn.secondary:hover {
  background: #f7fafc;
  border-color: #cbd5e0;
}

.action-btn.primary {
  background: #667eea;
  color: white;
}

.action-btn.primary:hover {
  background: #5a67d8;
  transform: translateY(-1px);
}

@media (max-width: 768px) {
  .orders-container {
    padding: 16px;
  }
  
  .page-header h1 {
    font-size: 2rem;
  }
  
  .summary-cards {
    grid-template-columns: 1fr;
  }
  
  .order-header {
    flex-direction: column;
    gap: 16px;
    align-items: flex-start;
  }
  
  .order-summary {
    width: 100%;
    justify-content: space-between;
  }
  
  .table-header, .table-row {
    grid-template-columns: 2fr 0.8fr 1fr 1fr;
    font-size: 0.9rem;
  }
  
  .order-actions {
    flex-direction: column;
  }
}
</style>